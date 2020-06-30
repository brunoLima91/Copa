const proxy = [
    {
      context: '/api',
      target: 'https://localhost:44303',
      pathRewrite: {'^/api' : ''}
    }
  ];
  
  module.exports = proxy;