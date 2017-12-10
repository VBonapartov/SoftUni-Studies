package softuniBlog.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import softuniBlog.entity.Article;

@Repository
public interface ArticleRepository extends JpaRepository<Article, Integer> {

}
