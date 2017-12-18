const Product = require('../models/Product');

module.exports = {
	index: (req, res) => {
        Product.find()
            .limit(30)
            .then(products => {
                res.render('product/index', {
                    'entries': products,
                });
            });
    	},
	createGet: (req, res) => {
        res.render('product/create');
	},
	createPost: (req, res) => {
        let product = req.body;

        Product.create(product)
            .then(product => {
                return res.redirect('/');
            })
            .catch(err => {
                product.error = 'Cannot add new product.';
                return res.render('product/create', product);
            });
	},
	editGet: (req, res) => {
        let productId = req.params.id;

        Product.findById(productId)
            .then(product => {
                if (product) {
                    return res.render('product/edit', product);
                }
                else {
                    return res.redirect('/');
                }
            })
            .catch(err => {
                return res.redirect('/')
            });
	},
	editPost: (req, res) => {
        let product = req.body;
        let productId = req.params.id;

        Product.findByIdAndUpdate(productId, product, {runValidators: true})
            .then(products => {
                return res.redirect("/");
            })
            .catch(err => {
                product.id = productId;
                product.error = "Cannot edit product.";

                return res.render("product/edit", product);
            });
	}
};