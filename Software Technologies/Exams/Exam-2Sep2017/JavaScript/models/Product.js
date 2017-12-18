const mongoose = require('mongoose');

let productSchema = mongoose.Schema({
	priority : {type: Number, required: true},
    name: {type: String, required: true},
	quantity: {type: Number, required: true},
    status: {type: String, required: true}
});

let Product = mongoose.model('Product', productSchema);

module.exports = Product;