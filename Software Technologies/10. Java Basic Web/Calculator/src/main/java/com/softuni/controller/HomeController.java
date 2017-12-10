package com.softuni.controller;

import com.softuni.entity.Calculator;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
	@GetMapping("/")
	public String index(Model model) {
		model.addAttribute("operator", "+");
		model.addAttribute("view", "views/calculatorForm");
		return "base-layout";
	}

	@PostMapping("/")
	public String calculate(@RequestParam String leftOperand,
							@RequestParam String operator,
							@RequestParam String rightOperand,
							Model model) {

		double num1;
		double num2;

		boolean incorrectNumber = false;
		try {
		num1 = Double.parseDouble(leftOperand);
		} catch (NumberFormatException ex) {
			num1 = 0;
			incorrectNumber = true;
		}

		try {
			num2 = Double.parseDouble(rightOperand);
		} catch (NumberFormatException ex) {
			num2 = 0;
			incorrectNumber = true;
		}

		if(!incorrectNumber) {
			Calculator calculator = new Calculator(num1, num2, operator);

			double result = calculator.caluclateResult();

			model.addAttribute("leftOperand", calculator.getLeftOperand());
			model.addAttribute("operator", calculator.getOperator());
			model.addAttribute("rightOperand", calculator.getRightOperand());

			model.addAttribute("result", result);
		} else {
			model.addAttribute("leftOperand", "");
			model.addAttribute("operator", "");
			model.addAttribute("rightOperand", "");

			model.addAttribute("result", "");
		}

		model.addAttribute("view", "views/calculatorForm");
		return "base-layout";
	}
}
