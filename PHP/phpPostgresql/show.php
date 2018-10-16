<?php
require_once("connection.php");
require_once("PgSQLOperate.php");

try {
    $conn = Connection::get()->connect();
    $pgoperate = new PgSQLOperate($conn);
    $books = $pgoperate->getbooks();

    //pg_connect
    // $books = [];
    // query data by pg_query() 
    // $result = pg_query($conn, "select * from book");
    // $books = pg_fetch_all($result) ;
} catch (Exception $e) {
    var_dump($e);
}
?>

<!DOCTYPE html>
<html>
    <head>
        <title>show all books - a simple app</title>
        <link rel="stylesheet"  href="https://cdn.rawgit.com/twbs/bootstrap/v4-dev/dist/css/bootstrap.css">
    </head>

    <body>
 <hr />
        <div class="container">
		
            <h1>Book List</h1>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>ID: </th>
                        <th>Name: </th>
                        <th>Author: </th>
                        <th>Publisher: </th>
                        <th>Date: </th>
                        <th>Price: </th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($books as $book) : ?>
                    <tr>
                        <td><?php echo htmlspecialchars($book['book_id']) ?></td>
                        <td><?php echo htmlspecialchars($book['bookname']) ?></td>
                        <td><?php echo htmlspecialchars($book['author']) ?></td>
                        <td><?php echo htmlspecialchars($book['publisher']) ?></td>
                        <td><?php echo htmlspecialchars($book['date_of_publication']) ?></td>
                        <td><?php echo htmlspecialchars($book['price']) ?></td>
                    </tr>
                    <?php endforeach;?>
                </tbody>
            </table>
        </div>
    </body>
</html>