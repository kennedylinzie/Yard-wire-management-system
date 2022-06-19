<?php



function cryptO(string $password) {

  $hash = md5($password);
  return $hash;
}

?>
