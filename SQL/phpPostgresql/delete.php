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
        <form name="display" action="delete.php" method="POST">
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

$row = $pgoperate->deletebooks($_POST[bookidOrigin]); 
echo $rows;
?>
