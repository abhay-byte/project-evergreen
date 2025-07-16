const express = require('express');
const router = express.Router();
const authController = require('../controllers/authController');
const authenticateToken = require('../middleware/auth');

router.post('/register', authController.register);
router.post('/login', authController.login);

// 🔐 Protected route to get current user
router.get('/me', authenticateToken, async (req, res) => {
  const { PrismaClient } = require('@prisma/client');
  const prisma = new PrismaClient();

  try {
    const user = await prisma.user.findUnique({
      where: { id: req.user.userId },
      select: {
        id: true,
        email: true,
        fullName: true,
        role: true,
        greenScore: true
      }
    });

    if (!user) return res.status(404).json({ error: 'User not found' });

    res.status(200).json({ user });
  } catch (err) {
    console.error(err);
    res.status(500).json({ error: 'Failed to fetch user' });
  }
});

module.exports = router;
