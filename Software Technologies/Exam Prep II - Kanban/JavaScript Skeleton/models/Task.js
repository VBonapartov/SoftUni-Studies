const mongoose = require('mongoose');

let taskSchema = mongoose.Schema({
    title: {type: String, required: true},
    status: {type: String, required: true},
});

let Task = mongoose.model('Task', taskSchema);

module.exports = Task;