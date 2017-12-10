import java.util.Scanner;

public class URLParser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String url = scanner.nextLine();

        System.out.printf("[protocol] = \"%s\"\n", GetProtocol(url));
        System.out.printf("[server] = \"%s\"\n", GetServer(url));
        System.out.printf("[resource] = \"%s\"\n", GetResource(url));
    }

    private static String GetProtocol(String url) {
        String protocol = "";
        if(url.contains("//")) {
            String[] urlParams = url.split("//");
            protocol = urlParams[0].substring(0, urlParams[0].length() - 1);
        }

        return protocol;
    }

    private static String GetServer(String url) {
        String server = "";
        if(url.contains("//")) {
            url = url.substring(url.indexOf("//") + 2);
        }

        server = url;
        if(url.contains("/")) {
            server = url.substring(0, url.indexOf("/"));
        }

        return server;
    }

    private static String GetResource(String url) {
        if(url.contains("//")) {
            url = url.substring(url.indexOf("//") + 2);
        }

        if(url.contains("/")) {
            return url.substring(url.indexOf("/") + 1);
        } else {
            return "";
        }
    }
}
