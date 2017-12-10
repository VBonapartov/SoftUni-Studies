const mongoose = require('mongoose');

let filmSchema = mongoose.Schema({
    name: {type: String, required: true},
    genre: {type: String, required: true},
    director: {type: String, required: true},
    year: {type: Number, required: true}
});

let Film = mongoose.model('Film', filmSchema);

module.exports = Film;