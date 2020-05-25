<!DOCTYPE html>
<html>
    <head>
    <title>update data - simple web application</title>
    <meta Http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <style>       li {list-style:none; }       </style> 
    </head>
    <body>
    <h2>Enter bookid</h2>
    <ul>
        <form name="display" action="update.php" method="POST">
            <li>Book ID:</li> <li><input type="text" name="bookidOrigin"></li>
            <li><input type="submit" name="submit"></li>
            
        </form>
    </ul>
    </body>
</html>

<?php
require_once('connection.php');
require_once("PgSQLOperate.php");

try {
    $conn=Connection::get()->connect();
    $pgoperate = new PgSQLOperate($conn);
} catch (Exception $e) {
    echo 'error: connection '.$e->getMessage();
}

if (!$conn) :
    echo "error: connect database"+ pg_last_error($conn).PHP_EOL ;
endif;

$row =(array)$pgoperate->getbooks($_POST[bookidOrigin]);

if (isset($_POST['submit'])) {
    echo "<ul>
    <form name='update' action='update.php' method='POST' >
        <li>Book ID:</li><li><input type='text' name='bookid' value='$row[book_id]' readonly /></li>
        <li>Book Name:</li><li><input type='text' name='bookname' value='$row[bookname]' />
        </li><li>Author:</li><li><input type='text' name='author' value='$row[author]' /></li> 
        <li>Publisher:</li><li><input type='text' name='publisher' value='$row[publisher]' /></li>  
        <li>Date of publication:</li><li><input type='text' name='datepub' value='$row[date_of_publication]' /></li>
        <li>Price (USD):</li><li><input type='text' name='price' value='$row[price]' /></li>
        <li><input type='submit' name='new' /></li>
    </form>
</ul>";
}
if (isset($_POST['new'])) {
    //PDO
    $update = $pgoperate->updatebooks($_POST[bookid], $_POST[bookname], $_POST[author], $_POST[publisher], $_POST[datepub], $_POST[price]);
    echo $update;

    //pg_connect
    //$db = pg_connect('host=104.209.45.95 dbname=postgres user=postgres password=PDQ5gmadmgQC port=5432');
    // $result = pg_query($conn, "SELECT * FROM book where book_id = '$_POST[bookid]'");
    // $row = pg_fetch_assoc($result);
    // $query = "UPDATE book SET bookname = '$_POST[bookname]',
    // author = '$_POST[author]', publisher = '$_POST[publisher]',date_of_publication = '$_POST[datepub]',
    // price = '$_POST[price]' where  book_id = '$_POST[bookid]';";
    // $result1 = pg_query($conn, $query);
    // if (!$result1) {
    //     echo $query;
    //     echo "Update failed!!".preg_last_error().PHP_EOL;
    // }
}
?>
