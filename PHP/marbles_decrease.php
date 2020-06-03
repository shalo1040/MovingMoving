<?php
	$userID = $_POST["userID"];
	$marble = $_POST["marble"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	if($marble == "lv1")
		$sql = "update Marbles SET lv1 = lv1 - 1 WHERE userID = '$userID' AND lv1 > 0";
	else if($marble == "lv2")
		$sql = "update Marbles SET lv2 = lv2 - 1 WHERE userID = '$userID' AND lv2 > 0";
	else
		$sql = "update Marbles SET lv3 = lv3 - 1 WHERE userID = '$userID' AND lv3 > 0";

	mysqli_query($con, $sql);
	mysqli_close($con);
?>