-- CreateEnum
CREATE TYPE "Role" AS ENUM ('shopper', 'store_manager', 'charity_rep', 'admin');

-- CreateEnum
CREATE TYPE "ManifestStatus" AS ENUM ('pending_approval', 'available', 'claimed', 'completed', 'cancelled');

-- CreateTable
CREATE TABLE "User" (
    "id" SERIAL NOT NULL,
    "email" TEXT NOT NULL,
    "password" TEXT NOT NULL,
    "fullName" TEXT,
    "role" "Role" NOT NULL DEFAULT 'shopper',
    "greenScore" INTEGER NOT NULL DEFAULT 0,
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "User_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "Product" (
    "id" SERIAL NOT NULL,
    "name" TEXT NOT NULL,
    "description" TEXT,
    "price" DOUBLE PRECISION NOT NULL,
    "imageUrl" TEXT,
    "greenScore" INTEGER NOT NULL,
    "greenScoreDetails" JSONB,
    "model3DUrl" TEXT,
    "category" TEXT,
    "inventoryQuantity" INTEGER NOT NULL DEFAULT 0,
    "expiryDate" TIMESTAMP(3),

    CONSTRAINT "Product_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "Charity" (
    "id" SERIAL NOT NULL,
    "name" TEXT NOT NULL,
    "address" TEXT,
    "contactEmail" TEXT,
    "isVerified" BOOLEAN NOT NULL DEFAULT false,
    "userId" INTEGER NOT NULL,

    CONSTRAINT "Charity_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "DonationManifest" (
    "id" SERIAL NOT NULL,
    "status" "ManifestStatus" NOT NULL DEFAULT 'pending_approval',
    "createdById" INTEGER,
    "claimedById" INTEGER,
    "scheduledPickup" TIMESTAMP(3),
    "createdAt" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "updatedAt" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "DonationManifest_pkey" PRIMARY KEY ("id")
);

-- CreateTable
CREATE TABLE "ManifestItem" (
    "id" SERIAL NOT NULL,
    "manifestId" INTEGER NOT NULL,
    "productId" INTEGER NOT NULL,
    "quantity" INTEGER NOT NULL,

    CONSTRAINT "ManifestItem_pkey" PRIMARY KEY ("id")
);

-- CreateIndex
CREATE UNIQUE INDEX "User_email_key" ON "User"("email");

-- CreateIndex
CREATE UNIQUE INDEX "Charity_userId_key" ON "Charity"("userId");

-- CreateIndex
CREATE UNIQUE INDEX "ManifestItem_manifestId_productId_key" ON "ManifestItem"("manifestId", "productId");

-- AddForeignKey
ALTER TABLE "Charity" ADD CONSTRAINT "Charity_userId_fkey" FOREIGN KEY ("userId") REFERENCES "User"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "ManifestItem" ADD CONSTRAINT "ManifestItem_manifestId_fkey" FOREIGN KEY ("manifestId") REFERENCES "DonationManifest"("id") ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE "ManifestItem" ADD CONSTRAINT "ManifestItem_productId_fkey" FOREIGN KEY ("productId") REFERENCES "Product"("id") ON DELETE RESTRICT ON UPDATE CASCADE;
