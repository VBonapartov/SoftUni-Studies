package com.softuni.entity;

public class Calculator {
    private double leftOperand;
    private double rightOperand;
    private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator) {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double caluclateResult() {
        double result;

        if (this.operator.equals("+")) {
            result = this.leftOperand + this.rightOperand;
        } else if (this.operator.equals("-")) {
            result = this.leftOperand - this.rightOperand;
        } else if (this.operator.equals("*")) {
            result = this.leftOperand * this.rightOperand;
        } else if (this.operator.equals("/")) {
            result = this.leftOperand / this.rightOperand;
        } else if (this.operator.equals("^")) {
            result = Math.pow(this.leftOperand, this.rightOperand);
        } else if (this.operator.equals("AND")) {
            result = (int)this.leftOperand & (int)this.rightOperand;
        } else if (this.operator.equals("OR")) {
            result = (int)this.leftOperand | (int)this.rightOperand;
        } else if (this.operator.equals("XOR")) {
            result = (int)this.leftOperand ^ (int)this.rightOperand;
        } else {
            result = 0;
        }

        return result;
    }

    public double getLeftOperand() {
        return leftOperand;
    }

    public void setLeftOperand(double leftOperand) {
        this.leftOperand = leftOperand;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public void setRightOperand(double rightOperand) {
        this.rightOperand = rightOperand;
    }

    public String getOperator() {
        return operator;
    }

    public void setOperator(String operator) {
        this.operator = operator;
    }
}
