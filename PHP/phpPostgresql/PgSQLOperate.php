<?php

class PgSQLOperate
{

    private $pdo;

    public function __construct($pdo)
    {
        $this->pdo=$pdo;
    }

    public function getbooks($id = null)
    {
        if (is_null($id)) :
            $sql = "select * from book";
            $stmt = $this->pdo->query($sql);
            $books=[];
            while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) :
                    $books[] = [
                        'book_id' => $row['book_id'],
                        'bookname' => $row['bookname'],
                        'author' => $row['author'],
                        'publisher' => $row['publisher'],
                        'date_of_publication' => $row['date_of_publication'],
                        'price' => $row['price'],
                    ];
            endwhile;
            return $books;
        else :
            $stmt = $this->pdo->prepare("select * from book where book_id = :bookid");
            $stmt->bindvalue(':bookid', $id);
            $stmt->execute();
            return $stmt->fetchobject();
        endif;
    }

    public function deletebooks($id)
    {
        if ($id == 'all') :
            $sql = "delete from book";
            $stmt = $this->pdo->prepare($sql);
            $stmt->execute();
            return $stmt->rowCount();
        elseif (!is_null($id)) :
            $stmt = $this->pdo->prepare("delete from book where book_id = :bookid");
            $stmt->bindvalue(':bookid', $id);
            $stmt->execute();
            return $stmt->rowCount();
        endif;
    }

    public function insertbooks($id, $name, $author, $publisher, $datepub, $price)
    {
        try {
            $sql = "insert into book (book_id,bookname,author,publisher,date_of_publication,price) values (:bookid,:bookname,
                :author,:publisher,:datepub,:price)";

            $stmt = $this->pdo->prepare($sql);

            $stmt->bindvalue(':bookid', $id);
            $stmt->bindvalue(':bookname', $name);
            $stmt->bindvalue(':author', $author);
            $stmt->bindvalue(':publisher', $publisher);
            $stmt->bindvalue(':datepub', $datepub);
            $stmt->bindvalue(':price', $price);

            $stmt->execute();
        } catch (Exception $e) {
            return  'insert fail';
        }
        return 'insert success';//$this->pdo->lastInsertId('book_book_id_seq');
    }

    public function updatebooks($id, $name, $author, $publisher, $datepub, $price)
    {
        $sql = "UPDATE book SET bookname = :bookname, 
                author = :author, publisher = :publisher,date_of_publication = :datepub,
                price = :price where  book_id = :bookid;";

        $stmt = $this->pdo->prepare($sql);

        $stmt->bindvalue(':bookid', $id);
        $stmt->bindvalue(':bookname', $name);
        $stmt->bindvalue(':author', $author);
        $stmt->bindvalue(':publisher', $publisher);
        $stmt->bindvalue(':datepub', $datepub);
        $stmt->bindvalue(':price', $price);

        $stmt->execute();

        return $stmt->rowCount();
    }
}
