const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find()
            .limit(30)
            .then(tasks => {
                             res.render('task/index', {'tasks': tasks});
                           });
    },

	createGet: (req, res) => {
        res.render('task/create', {'tasks': null});
	},

    createPost: (req, res) => {
        let task = req.body;

        if(!task.title || !task.comments) {
            res.redirect('/');
            return;
        }

        Task.create(task)
            .then(task => {
                            res.redirect('/');
                          })
            .catch(err => {
                            task.error = 'Cannot create task.';
                            res.render('task/create', task);
                          });
    },

	// createPost: (req, res) => {
     //    let taskArgs = req.body;
    //
     //    let errorMsg = '';
     //    if (!taskArgs.title) {
     //        errorMsg = 'Invalid title!';
     //    } else if(!taskArgs.comments) {
     //        errorMsg = 'Invalid comments!';
     //    }
    //
     //    if(errorMsg) {
     //        res.render('task/create');
     //        return;
     //    }
    //
     //    Task.create(taskArgs);
     //    res.redirect('/');
	// },

    deleteGet: (req, res) => {
        let taskId = req.params.id;

        Task.findById(taskId)
            .then(task => {
                            if (task) {
                                return res.render('task/delete', task);
                            }
                            else {
                                return res.redirect('/');
                            }
                          })
            .catch(err => {
                            res.redirect('/')
                          });
    },

    // deleteGet: (req, res) => {
    //    Task.findById(req.params.id, function(err, task) {
    //    	if(err || task === null) {
    //            res.redirect('/');
    // 		} else {
    //            res.render('task/delete', {
    //                id: task.id,
    //                title: task.title,
    //                comments: task.comments
    //            });
    //        }
    //    });
    // },

    deletePost: (req, res) => {
        let taskId = req.params.id;

        Task.findByIdAndRemove(taskId)
            .then(task => {
                            res.redirect('/');
                          })
            .catch(err => {
                            res.redirect('/')
                          });
    }

    // deletePost: (req, res) => {
    //    Task.remove({ _id: req.params.id }, function(err) {
    //        if (!err) {
    //            let tre = 1;
    //        }
    //        else {
    //            let ert = 1;
    //        }
    //
    //        res.redirect('/');
    //    });
    // }
};