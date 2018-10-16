<!DOCTYPE html>
<head>
<title>Insert into Postgresql with PHP - a simple web application </title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style> li {list-style: none;}</style>
</head>
<body>
    <h2>Endter information regarding book</h2>
        <ul>
            <form name="insert" action="insert.php" method="POST">
                <li>Book ID:</li><li><input type="text" name="bookid"></li>
                <li>Book Name:</li><li><input type="text" name="bookname"></li>
                <li>Author :</li><li><input type="text" name="author"></li>
                <li>Publisher:</li><li><input type="text" name="publisher"></li>
                <li>Date of pub:</li><li><input type="text" name="datepub"></li>
                <li>Price($) :</li><li><input type="text" name="price"></li>
                <li><input type="submit"></li>
            </form>
        </ul>
</body>
<html>

<?php
require_once('connection.php');
require_once("PgSQLOperate.php");

try {
    $conn=Connection::get()->connect();
    //PDO insert allow multi 
    $pgoperate = new PgSQLOperate($conn);
    $insert = $pgoperate->insertbooks($_POST[bookid],$_POST[bookname],$_POST[author],$_POST[publisher],$_POST[datepub],$_POST[price]);
    echo $insert;

} catch (Exception $e) {
    echo 'error: connection '.$e->getMessage();
}
 
//pg_connect
//$db = pg_connect('host=104.209.45.95 dbname=postgres user=postgres password=PDQ5gmadmgQC port=5432'); 
// $query = "insert into book (book_id,bookname,author,publisher,date_of_publication,price) values ('$_POST[bookid]','$_POST[bookname]',
// '$_POST[author]','$_POST[publisher]','$_POST[datepub]','$_POST[price]')";

// $result  = pg_query($conn, $query);
// if (!$result) :
//     echo $query.PHP_EOL;
//     echo "error: insert database " + pg_last_error($result).PHP_EOL ;
// else :
//     echo "success: insert database".PHP_EOL;
// endif;
?>


