import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

public class CountWorkingDays {
    public static void main(String[] args) throws ParseException {
        Scanner scanner = new Scanner(System.in);

        SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy", Locale.getDefault());

        Calendar startDate = Calendar.getInstance();
        Calendar endDate = Calendar.getInstance();

        startDate.setTime(format.parse(scanner.nextLine()));
        endDate.setTime(format.parse(scanner.nextLine()));

        List<Calendar> holidays = new ArrayList<Calendar>();

        for(int i = 0; i < 11; i++) {
            holidays.add(Calendar.getInstance());
        }

        holidays.get(0).setTime(format.parse("01-01-1970"));
        holidays.get(1).setTime(format.parse("03-03-1970"));
        holidays.get(2).setTime(format.parse("01-05-1970"));
        holidays.get(3).setTime(format.parse("06-05-1970"));
        holidays.get(4).setTime(format.parse("24-05-1970"));
        holidays.get(5).setTime(format.parse("06-09-1970"));
        holidays.get(6).setTime(format.parse("22-09-1970"));
        holidays.get(7).setTime(format.parse("01-11-1970"));
        holidays.get(8).setTime(format.parse("24-12-1970"));
        holidays.get(9).setTime(format.parse("25-12-1970"));
        holidays.get(10).setTime(format.parse("26-12-1970"));

        int countOfWorkingDays = 0;
        endDate.add(Calendar.DATE, 1);

        for(Calendar currentDate = startDate; currentDate.before(endDate); currentDate.add(Calendar.DATE, 1)) {
            if(currentDate.get(Calendar.DAY_OF_WEEK) != Calendar.SATURDAY &&
                    currentDate.get(Calendar.DAY_OF_WEEK) != Calendar.SUNDAY) {

                boolean isNotHoliday = true;

                for(Calendar holiday : holidays) {
                    if(holiday.get(Calendar.DAY_OF_MONTH) == currentDate.get(Calendar.DAY_OF_MONTH) &&
                            holiday.get(Calendar.MONTH) == currentDate.get(Calendar.MONTH)) {
                        isNotHoliday = false;
                        break;
                    }
                }

                if(isNotHoliday) {
                    countOfWorkingDays++;
                }
            }
        }

        System.out.println(countOfWorkingDays);
    }
}
