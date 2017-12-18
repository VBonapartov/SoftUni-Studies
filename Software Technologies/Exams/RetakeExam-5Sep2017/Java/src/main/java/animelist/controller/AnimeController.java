package animelist.controller;

import animelist.entity.Anime;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import animelist.bindingModel.AnimeBindingModel;
import animelist.repository.AnimeRepository;

import java.util.List;

@Controller
public class AnimeController {

	private final AnimeRepository animeRepository;

	@Autowired
	public AnimeController(AnimeRepository animeRepository) {
		this.animeRepository = animeRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Anime> animes = this.animeRepository.findAll();

		model.addAttribute("animes", animes);
		model.addAttribute("view", "anime/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "anime/create");

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, AnimeBindingModel animeBindingModel) {
		if(animeBindingModel == null) {
			return "redirect:/";
		}

		if(animeBindingModel.getName().equals("") || animeBindingModel.getRating() == null ||
				animeBindingModel.getDescription().equals("") || animeBindingModel.getWatched().equals("")) {
			return "redirect:/";
		}

		Anime animeEntity = new Anime (
				animeBindingModel.getRating(),
				animeBindingModel.getName(),
				animeBindingModel.getDescription(),
				animeBindingModel.getWatched()
		);

		this.animeRepository.saveAndFlush(animeEntity);

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		if(!this.animeRepository.exists(id)) {
			return "redirect:/";
		}

		Anime anime = this.animeRepository.findOne(id);

		model.addAttribute("anime", anime);
		model.addAttribute("view", "anime/delete");

		return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(Model model, @PathVariable int id, AnimeBindingModel animeBindingModel) {
		if(!this.animeRepository.exists(id)) {
			return "redirect:/";
		}

		Anime anime = this.animeRepository.findOne(id);

		this.animeRepository.delete(anime);

		return "redirect:/";
	}
}
