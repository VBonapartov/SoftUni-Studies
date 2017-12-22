package lognoziroh.entity;

import javax.persistence.*;

@Entity
@Table(name = "reports")
public class Report {
    private Integer id;
    private String message;
    private String status;
    private String origin;

    public Report(String message, String status, String origin) {
        this.message = message;
        this.status = status;
        this.origin = origin;
    }

    public Report() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    @Column(nullable = false)
    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    @Column(nullable = false)
    public String getOrigin() {
        return origin;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }
}
