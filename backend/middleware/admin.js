const jwt = require('jsonwebtoken');

const isAdmin = (req, res, next) => {
  const authHeader = req.headers['authorization'];
  const token = authHeader && authHeader.split(' ')[1];

  if (!token) return res.status(401).json({ error: 'Token missing' });

  try {
    const decoded = jwt.verify(token, process.env.JWT_SECRET);
    if (decoded.role !== 'admin') {
      return res.status(403).json({ error: 'Access denied. Admins only.' });
    }

    req.user = decoded; // Save user info to request
    next();
  } catch (err) {
    console.error('Admin middleware error:', err);
    res.status(403).json({ error: 'Invalid or expired token' });
  }
};

module.exports = isAdmin;
