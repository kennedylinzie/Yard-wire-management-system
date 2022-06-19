<?php
   require("conn.php");

   //$loginUser =$_POST["loginUser"];
  // $loginPass =$_POST["loginPass"];

//pull data for the drop down in centra
if($_POST['key']==1)
 {



$sql = "SELECT Vehicle FROM all_data";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);

}
//filter specific train
if($_POST['key']==2)
 {


$v_number = mysqli_real_escape_string($conn,$_POST['v_number']);

$sql = "SELECT * FROM all_data WHERE Vehicle='$v_number'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);

}

//update train info
if($_POST['key']==3)
 {
    $v_number = mysqli_real_escape_string($conn,$_POST['v_number']);
    $Line = mysqli_real_escape_string($conn,$_POST['Line']);
    //$No_of_wagons = mysqli_real_escape_string($conn,$_POST['No_of_wagons']);
    $Date_Hour_Last_Event = mysqli_real_escape_string($conn,$_POST['Date_Hour_Last_Event']);
    $Status = mysqli_real_escape_string($conn,$_POST['Status']);

    //$sql = "SELECT * FROM all_data WHERE Vehicle='$v_number'";

    $sql = "UPDATE all_data SET Line='$Line',Date_Hour_Last_Event='$Date_Hour_Last_Event',Status='$Status' WHERE Vehicle='$v_number'";

    $result = mysqli_query($conn, $sql);

    if (mysqli_query($conn, $sql)) {
      echo "successfully";
    } else {
      echo "Error updating record: " . mysqli_error($conn);
    }


    mysqli_close($conn);

}


if($_POST['key']==4)
 {
    $v_number = mysqli_real_escape_string($conn,$_POST['v_number']);
    $Line = mysqli_real_escape_string($conn,$_POST['Line']);
    $posy = mysqli_real_escape_string($conn,$_POST['posY']);
    $pox = mysqli_real_escape_string($conn,$_POST['posX']);


    //$sql = "SELECT * FROM all_data WHERE Vehicle='$v_number'";

    $sql = "UPDATE all_data SET Line='$Line',posX='$pox',posY='$posy' WHERE Vehicle='$v_number'";

    $result = mysqli_query($conn, $sql);

    if (mysqli_query($conn, $sql)) {
      echo "Position update Successful";
    } else {
      echo "Error modifying position: " . mysqli_error($conn);
    }


    mysqli_close($conn);

}

//pull data of un released trains
if($_POST['key']==5)
 {



$sql = "SELECT * FROM all_data WHERE Relesed_from_system='no'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);

}


//set the released value to no or yes
if($_POST['key']==6)
 {
  $relesed_state = mysqli_real_escape_string($conn,$_POST['released_state']);
  $v_number = mysqli_real_escape_string($conn,$_POST['v_number']);
  $d_home = mysqli_real_escape_string($conn,$_POST['data_home']);




$sql = "UPDATE all_data SET Relesed_from_system='$relesed_state', Data_home='$d_home'  WHERE Vehicle='$v_number'";
$result = mysqli_query($conn, $sql);


  if (mysqli_query($conn, $sql)) {
    echo "modification Successful";
  } else {
    echo "Error modifying train release: " . mysqli_error($conn);
  }

mysqli_close($conn);

}

if($_POST['key']==7)
 {



    $Name =$_POST["name"];
    $posx =$_POST["posx"];
    $posy =$_POST["posy"];
    $obj_tag =$_POST["obj_tag"];



  // $sql = "SELECT name  FROM object_persist WHERE name='". $Name."'";
   $sql = "INSERT INTO `object_persist`(`object_id`, `name`, `posx`, `posy`, `obj_tag`) VALUES ('','$Name','$posx','$posy','$obj_tag')";
  // $result = mysqli_query($conn, $sql);

         if (mysqli_query($conn, $sql)) {
              echo "Train received";
          } else {
            $str = mysqli_error($conn);
            $pattern = "/Duplicate entry/i";
            echo preg_match($pattern, $str);

          }


    mysqli_close($conn);

}


if($_POST['key']==8)
 {

    $Name =$_POST["name"];
    $posx =$_POST["posx"];
    $posy =$_POST["posy"];

    $sql = "UPDATE object_persist SET posx='$posx', posy='$posy'  WHERE name='$Name'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}

//pull data of un released trains
if($_POST['key']==9)
 {


$sql = "SELECT * FROM object_persist";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);

}
//get all data related to a persistent train
if($_POST['key']==10)
 {

$Data_home =$_POST["Data_home"];

$sql = "SELECT * FROM all_data WHERE Data_home='".$Data_home."'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);

}

//get all active wagons
if($_POST['key']==11)
 {

    $Data_home =$_POST["Data_home"];

    $sql = "SELECT * FROM all_data WHERE Data_home='".$Data_home."' AND Relesed_from_system='no'";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {
      // output data of each row
      $row = array();
          while($row = mysqli_fetch_assoc($result)) {

          $rows[] = $row;
          }
      echo json_encode($rows);
    } else {
    //  echo "0 results";
}

mysqli_close($conn);

}

//remove active cargo from wagon
if($_POST['key']==12)
 {

    $Vehicle =$_POST["Vehicle"];


    $sql = "UPDATE all_data SET	Relesed_from_system='yes', Data_home=''  WHERE Vehicle='$Vehicle'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}


//remove the whole trian with cargo
if($_POST['key']==13)
 {

    $name = $_POST["name"];


    $sql = "DELETE FROM object_persist WHERE name='$name'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}



?>
