import java.util.ArrayList;
import java.util.Scanner;

public class AverageGrades {
     public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        ArrayList<Student> students = new ArrayList<Student>();

        for(int i = 0; i < n; i++) {
            String[] inputArguments = scanner.nextLine().split(" ");

            Student student = new Student();
            student.setName(inputArguments[0]);
            student.setGrades(new ArrayList<Double>());

            ArrayList<Double> grades = new ArrayList<>();
            for(int j = 1; j < inputArguments.length; j++) {
                grades.add(Double.parseDouble(inputArguments[j]));
            }
            student.setGrades(grades);

            students.add(student);
        }

        ArrayList<Student> filteredStudents = new ArrayList<Student>();

        for(Student student : students) {
            if(student.AverageGrade() >= 5.00) {
                filteredStudents.add(student);
            }
        }

        filteredStudents.sort((student1, student2) ->
        {
            int result = student1.getName().compareTo(student2.getName());

            if(result == 0) {
                result = Double.compare(student2.AverageGrade(), student1.AverageGrade());
            }

            return result;
        });

        for(Student sortedStudent : filteredStudents) {
            System.out.println(sortedStudent.getName() + " -> " + String.format("%.2f", sortedStudent.AverageGrade()));
        }
    }
}

class Student {
    private String Name;

    private ArrayList<Double> Grades;

    public double AverageGrade() {
        double sum = 0;
        int count = Grades.size();

        for(Double grade : Grades) {
            sum += grade;
        }

        return sum / count;
    }

    public String getName() {
        return this.Name;
    }

    public void setName(String name) {
        this.Name = name;
    }

    public ArrayList<Double> getGrades() {
        return this.Grades;
    }

    public void setGrades(ArrayList<Double> grades) {
        this.Grades = grades;
    }
}