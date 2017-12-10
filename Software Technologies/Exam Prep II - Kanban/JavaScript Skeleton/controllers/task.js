const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {

        Task.find().find()
            .limit(30)
            .then(tasks => {
                res.render('task/index', {
                    'openTasks': tasks.filter(t => t.status === 'Open'),
                    'inProgressTasks': tasks.filter(t => t.status === 'In Progress'),
                    'finishedTasks': tasks.filter(t => t.status === 'Finished'),
                });
            });

        // let tasksPromises = [
        // 						Task.find({status : 'Open'}),
        //     					Task.find({status : 'In Progress'}),
        //     					Task.find({status : 'Finished'})
			// 				];
        //
        // Promise.all(tasksPromises)
			//     .then(taskResult => {
			// 		res.render('task/index', {
			// 			'openTasks' : tasksPromises[0],
        //                 'inProgressTasks' : tasksPromises[1],
        //                 'finishedTasks' : tasksPromises[2],
			// 		})
			// 	})
	},

	createGet: (req, res) => {
        res.render('task/create');
	},

	createPost: (req, res) => {
        let task = req.body;

        // if(!task.title || !task.status) {
        //     res.redirect('/');
        //     return;
        // }

        Task.create(task)
            .then(task => {
                return res.redirect('/');
            })
            .catch(err => {
                task.error = 'Cannot create task.';
                return res.render('task/create', task);
            });
	},

	editGet: (req, res) => {
        let taskId = req.params.id;

        Task.findById(taskId)
            .then(task => {
                if (task) {
                    return res.render('task/edit', task);
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
		let task = req.body;
        let taskId = req.params.id;

        // if(!taskBody.title || !taskBody.status) {
        //     res.redirect('/');
        //     return;
        // }

        Task.findByIdAndUpdate(taskId, task, {runValidators: true})
			.then(tasks => {
							return res.redirect("/");
						   })
			.catch(err => {
							task.id = taskId;
            				task.error = "Cannot edit task.";

							return res.render("task/edit", task);
			 			   });
	}
};