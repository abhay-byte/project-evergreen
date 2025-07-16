const { PrismaClient } = require('@prisma/client');
const prisma = new PrismaClient();

// Get all products
exports.getAllProducts = async (req, res) => {
  try {
    const { category } = req.query;

    const products = await prisma.product.findMany({
      where: category ? { category } : {},
    });

    res.status(200).json(products);
  } catch (err) {
    console.error('Error fetching products:', err);
    res.status(500).json({ error: 'Failed to fetch products' });
  }
};

// Get product by ID
exports.getProductById = async (req, res) => {
  try {
    const { id } = req.params;

    const product = await prisma.product.findUnique({
      where: { id: parseInt(id) },
    });

    if (!product) {
      return res.status(404).json({ error: 'Product not found' });
    }

    res.status(200).json(product);
  } catch (err) {
    console.error('Error fetching product by ID:', err);
    res.status(500).json({ error: 'Failed to fetch product' });
  }
};

// Create product
exports.createProduct = async (req, res) => {
  const {
    name,
    description,
    price,
    imageUrl,
    greenScore,
    greenScoreDetails,
    model3DUrl,
    category,
    inventoryQuantity,
    expiryDate,
  } = req.body;

  try {
    const product = await prisma.product.create({
      data: {
        name,
        description,
        price: parseFloat(price),
        imageUrl,
        greenScore,
        greenScoreDetails,
        model3DUrl,
        category,
        inventoryQuantity,
        expiryDate: new Date(expiryDate),
      },
    });

    res.status(201).json(product);
  } catch (err) {
    console.error('Create product error:', err);
    res.status(500).json({ error: 'Failed to create product' });
  }
};

// Update product
exports.updateProduct = async (req, res) => {
  const { id } = req.params;
  const updates = req.body;

  try {
    const product = await prisma.product.update({
      where: { id: parseInt(id) },
      data: updates,
    });

    res.status(200).json(product);
  } catch (err) {
    console.error('Update product error:', err);
    res.status(500).json({ error: 'Failed to update product' });
  }
};


// PUT /api/products/:id
exports.updateProduct = async (req, res) => {
    const { id } = req.params;
    const updates = req.body;
  
    try {
      const updatedProduct = await prisma.product.update({
        where: { id: parseInt(id) },
        data: updates,
      });
  
      res.status(200).json(updatedProduct);
    } catch (err) {
      console.error('Update product error:', err);
      res.status(500).json({ error: 'Failed to update product' });
    }
  };
  