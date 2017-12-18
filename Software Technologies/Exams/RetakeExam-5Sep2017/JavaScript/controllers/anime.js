const Anime = require('../models/Anime');

module.exports = {
	index: (req, res) => {
        Anime.find()
            .limit(30)
            .then(animes => {
                res.render('anime/index', {
                    'animes': animes,
                });
            });
	},
	createGet: (req, res) => {
        res.render('anime/create');
	},
	createPost: (req, res) => {
        let anime = req.body;

        Anime.create(anime)
            .then(anime => {
                return res.redirect('/');
            })
            .catch(err => {
                anime.error = 'Cannot create anime.';
                return res.render('anime/create', anime);
            });
	},
	deleteGet: (req, res) => {
        let animeId = req.params.id;

        Anime.findById(animeId)
            .then(anime => {
                if (anime) {
                    return res.render('anime/delete', anime);
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
        let animeId = req.params.id;

        Anime.findByIdAndRemove(animeId)
            .then(anime => {
                res.redirect('/');
            })
            .catch(err => {
                res.redirect('/')
            });
	}
};