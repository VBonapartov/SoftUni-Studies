const mongoose = require('mongoose');

let reportSchema = mongoose.Schema({
    status: {type: String, required: true},
    message: {type: String, required: true},
    origin: {type: String, required: true}
});

let Report = mongoose.model('Report', reportSchema);

module.exports = Report;