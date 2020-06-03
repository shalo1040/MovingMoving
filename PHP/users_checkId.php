<?php
	$userName = $_POST["userName"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "select * from Users ";
	$sql .="where userName = '$userName'";

	$result = mysqli_query($con, $sql);
	$num_of_rows = mysqli_num_rows($result);

	echo $num_of_rows;

	mysqli_free_result($result);
	mysqli_close($con);
?>