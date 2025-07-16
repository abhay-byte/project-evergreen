
const express = require('express');
const router = express.Router();
const productController = require('../controllers/productController');
const isAdmin = require('../middleware/admin');

// Public routes
router.get('/', productController.getAllProducts);
router.get('/:id', productController.getProductById);

// Admin routes
router.post('/', isAdmin, productController.createProduct);
router.put('/:id', isAdmin, productController.updateProduct);

module.exports = router;

