<?php
	$userID = $_POST["userID"];
	$monster = $_POST["monster"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "select * FROM Monsters WHERE userID = '$userID'";
	$result = mysqli_query($con, $sql);
	$row = mysqli_fetch_array($result);
	$check = $row[$monster];

	if($check=="0") {
		echo "false";
		$sql2 = "update Monsters SET ".mysqli_real_escape_string($con, $monster)." = 1 WHERE userID = '$userID'";
		mysqli_query($con, $sql2);
	} else echo "true";

	mysqli_close($con);
?>