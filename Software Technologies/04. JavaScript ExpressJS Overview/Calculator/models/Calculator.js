function Calculator(leftOperand, operator, rightOperand) {
    this.leftOperand = leftOperand;
    this.rightOperand = rightOperand;
    this.operator = operator;

    this.calculateResult = function () {
        let result = 0;

        switch(this.operator)
        {
            case "+":
                result = this.leftOperand + this.rightOperand;
                break;

            case "-":
                result = this.leftOperand - this.rightOperand;
                break;

            case "*":
                result = this.leftOperand * this.rightOperand;
                break;

            case "/":
                result = this.leftOperand / this.rightOperand;
                break;

            case "^":
                result = Math.pow(this.leftOperand, this.rightOperand);
                break;

            case "AND":
                result = this.leftOperand & this.rightOperand;
                break;

            case "OR":
                result = this.leftOperand | this.rightOperand;
                break;

            case "XOR":
                result = this.leftOperand ^ this.rightOperand;
                break;
        }

        return result;
    }
}

module.exports = Calculator;
