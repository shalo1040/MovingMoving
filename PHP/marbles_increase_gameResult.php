<?php
	$userID = $_POST["userID"];
	$marble1_str = $_POST["marble1"];
	$marble2_str = $_POST["marble2"];
	$marble3_str = $_POST["marble3"];

	$marble1 = intval($marble1_str);
	$marble2 = intval($marble2_str);
	$marble3 = intval($marble3_str);

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "update Marbles SET lv1 = lv1+'$marble1', lv2 = lv2+'$marble2', lv3 = lv3+'$marble3' WHERE userID = '$userID'";

	mysqli_query($con, $sql);
	mysqli_close($con);
?>