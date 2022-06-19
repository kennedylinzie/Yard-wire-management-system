<?php
   require("conn.php");
   require("encryption.php");

   if($_POST['key']==1)
    {

   $reg_name  = $_POST["name"];
   $regSurname  = $_POST["surname"];
   $regUserid = $_POST["userid"];
   $regPassword = $_POST["password"];
   $reUserType = $_POST["isSuper_user"];


    $sql = "SELECT U_userid FROM r_users WHERE U_userid='".$regUserid."'";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {

        echo "Use a diffrent user id";

    } else {
           $regPassword = cryptO($regPassword);

            $sql_regi = "INSERT INTO `r_users` (`UU_ID`, `U_name`, `U_surname`, `U_userid`, `U_Password`,`isSuper_user`)
            VALUES (NULL, '$reg_name', '$regSurname', '$regUserid', '$regPassword','$reUserType')";

            if (mysqli_query($conn, $sql_regi)) {
              echo "Registration Successful";
            } else {
              echo "Error: " . $sql_regi . "<br>" . mysqli_error($conn);
            }

    }

    mysqli_close($conn);
}



if($_POST['key']==2)
 {

    $sql = "SELECT COUNT(*) FROM r_users WHERE isSuper_user='yes'";
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
}


if($_POST['key']==3)
 {


$Vehicle_Type  = $_POST["Vehicle_Type"];
$Yard_Sector = $_POST["Yard_Sector"];
$Vehicle = $_POST["Vehicle"];
$Sequence = $_POST["Sequence"];
$Series  = $_POST["Series"];
$Wagon_type  = $_POST["Wagon_type"];
$Date_Hour_Last_Event = $_POST["Date_Hour_Last_Event"];
$Status = $_POST["Status"];



 $sql = "SELECT 	Vehicle FROM all_data WHERE 	Vehicle='".$Vehicle."'";
 $result = mysqli_query($conn, $sql);

 if (mysqli_num_rows($result) > 0) {

     echo "Wagon already exists";

 } else {
         $sql_regi = "INSERT INTO `all_data` (`transaction_id`, `Relesed_from_system`, `Vehicle_Type`, `Yard_Sector`, `Line`, `Vehicle`, `Sequence`, `Wagon_type`, `Series`, `Date_Hour_Last_Event`, `Status`, `posX`, `posY`, `Data_home`)
         VALUES (NULL,'yes', '$Vehicle_Type', '$Yard_Sector',NULL,'$Vehicle','','$Wagon_type','$Series','$Date_Hour_Last_Event','$Status','','','')";

         if (mysqli_query($conn, $sql_regi)) {
           echo "Registration Successful";
         } else {
           echo "Error: " . $sql_regi . "<br>" . mysqli_error($conn);
         }
 }

 mysqli_close($conn);
}



?>
