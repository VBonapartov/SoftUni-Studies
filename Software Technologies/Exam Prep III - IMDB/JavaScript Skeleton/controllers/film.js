const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        Film.find()
            .limit(30)
            .then(films => {
                res.render('film/index', {
                    'films': films,
                });
            });
	},
	createGet: (req, res) => {
        res.render('film/create');
	},
	createPost: (req, res) => {
        let film = req.body;

        Film.create(film)
            .then(film => {
                return res.redirect('/');
            })
            .catch(err => {
                film.error = 'Cannot create film.';
                return res.render('film/create', film);
            });
	},
	editGet: (req, res) => {
        let filmId = req.params.id;

        Film.findById(filmId)
            .then(film => {
                if (film) {
                    return res.render('film/edit', film);
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
        let film = req.body;
        let filmId = req.params.id;

        Film.findByIdAndUpdate(filmId, film, {runValidators: true})
            .then(films => {
                return res.redirect("/");
            })
            .catch(err => {
                film.id = filmId;
                film.error = "Cannot edit film.";

                return res.render("film/edit", film);
            });
	},
	deleteGet: (req, res) => {
        let filmId = req.params.id;

        Film.findById(filmId)
            .then(film => {
                if (film) {
                    return res.render('film/delete', film);
                }
                else {
                    return res.redirect('/');
                }
            })
            .catch(err => {
                res.redirect('/')
            });
	},
	deletePost: (req, res) => {
        let filmId = req.params.id;

        Film.findByIdAndRemove(filmId)
            .then(film => {
                res.redirect('/');
            })
            .catch(err => {
                res.redirect('/')
            });
	}
};