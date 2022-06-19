<?php
   require("conn.php");


$userID =$_POST["userID"];
$itemID =$_POST["itemID"];


$sql = "SELECT price FROM items WHERE ID='".$userID."'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  while($row = mysqli_fetch_assoc($result)) {

//store item price
          $itemprice = $row["price"];
     //second sql delete item
      $sql2 = "DELETE FROM useritems WHERE itemID=".$itemID." AND userID=".$userID."";
      $result2 = mysqli_query($conn, $sql2);
      if ($result2) {
        $sql3 = "UPDATE 'users' SET 'coins'= 'coins' + '".$itemprice."' WHERE uu_id=".$userID."";
        $result3 = mysqli_query($conn, $sql3);

      }

  }
} else {
  echo "";
}

mysqli_close($conn);





?>
