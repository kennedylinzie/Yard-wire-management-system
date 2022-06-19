<?php
   require("conn.php");
   require("encryption.php");

   if($_POST['key']==1)
    {

       $Userid =$_POST["userid"];
       $UserPass =$_POST["password"];

       $UserPass = cryptO($UserPass);

       $sql = "SELECT U_userid ,U_Password FROM r_users WHERE U_userid='".$Userid."'";
       $result = mysqli_query($conn, $sql);

        if (mysqli_num_rows($result) > 0) {
          // output data of each row
          while($row = mysqli_fetch_assoc($result)) {

            if($row["U_Password"] == $UserPass){
                //echo "LOGIN SUCCESSFUL"."<br>";
                  echo $row["U_userid"];
                //after this information cn be pulled

            }else{
                echo "Wrong password";

            }
          }
        } else {
          echo "Wrong User ID";
        }

    mysqli_close($conn);

}

if($_POST['key']==2)
 {

    $Userid =$_POST["userid"];

    $sql = "SELECT U_userid ,U_surname,U_name,isSuper_user,U_Password FROM r_users WHERE U_userid='".$Userid."'";
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



if($_POST['key']==3)
 {

    $userid = $_POST["user_id"];


    $sql = "DELETE FROM r_users WHERE U_userid='$userid'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}

if($_POST['key']==4)
 {

    $userid = $_POST["user_id"];
      $U_name = $_POST["U_name"];
        $U_surname = $_POST["U_surname"];
          $U_Password = $_POST["U_Password"];

          $U_Password = cryptO($U_Password);


    $sql = "UPDATE r_users SET	U_name='$U_name', U_surname='$U_surname', U_Password='$U_Password'  WHERE U_userid='$userid'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}


if($_POST['key']==5)
 {



    $sql = "SELECT * FROM r_users WHERE isSuper_user='no'";
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

if($_POST['key']==6)
 {

    $userid = $_POST["user_id"];



    $sql = "UPDATE r_users SET	isSuper_user='yes' WHERE U_userid='$userid'";

      if (mysqli_query($conn, $sql)) {
        echo "modification Successful";
      } else {
        echo "modification Failed";
      }

    mysqli_close($conn);

}

?>
