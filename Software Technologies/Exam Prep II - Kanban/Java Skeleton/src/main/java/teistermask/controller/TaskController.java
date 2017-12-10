package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

import java.util.List;
import java.util.stream.Collectors;

@Controller
public class TaskController {
	private final TaskRepository taskRepository;

	@Autowired
	public TaskController(TaskRepository taskRepository) {
		this.taskRepository = taskRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Task> tasks = this.taskRepository.findAll();

		//this.taskRepository.findAllByStatus(); Task.Repository.java !!!

		List<Task> openTasks = tasks.stream()
								.filter(task -> "Open".equals(task.getStatus()))
								.collect(Collectors.toList());

		List<Task> inProgressTasks = tasks.stream()
								.filter(task -> "In Progress".equals(task.getStatus()))
								.collect(Collectors.toList());

		List<Task> finishedTasks = tasks.stream()
								.filter(task -> "Finished".equals(task.getStatus()))
								.collect(Collectors.toList());

		model.addAttribute("openTasks", openTasks);
		model.addAttribute("inProgressTasks", inProgressTasks);
		model.addAttribute("finishedTasks", finishedTasks);
		model.addAttribute("view", "task/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "task/create");

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, TaskBindingModel taskBindingModel) {
		if(taskBindingModel == null) {
			return "redirect:/";
		}

		if(taskBindingModel.getTitle().equals("") || taskBindingModel.getStatus().equals("")) {
			return "redirect:/";
		}

		Task taskEntity = new Task (
				taskBindingModel.getTitle(),
				taskBindingModel.getStatus()
		);

		this.taskRepository.saveAndFlush(taskEntity);

		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		if(!this.taskRepository.exists(id)) {
			return "redirect:/";
		}

		Task task = this.taskRepository.findOne(id);

		model.addAttribute("task", task);
		model.addAttribute("view", "task/edit");

		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, TaskBindingModel taskBindingModel) {
		if(!this.taskRepository.exists(id)) {
			return "redirect:/";
		}

		if (taskBindingModel.getTitle().equals("") || taskBindingModel.getStatus().equals("")) {
			Task task = new Task();
			task.setId(id);
			task.setTitle(taskBindingModel.getTitle());
			task.setStatus(taskBindingModel.getStatus());

			model.addAttribute("task", task);
			model.addAttribute("view", "task/edit");

			return "base-layout";
		}

		Task task = this.taskRepository.findOne(id);
		if (task != null) {
			task.setTitle(taskBindingModel.getTitle());
			task.setStatus(taskBindingModel.getStatus());
			this.taskRepository.saveAndFlush(task);
		}

		return "redirect:/";
	}
}
