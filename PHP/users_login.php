<?php
	$userName = $_POST["userName"];
	$password = $_POST["password"];
	$passwordHash = md5($password);

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "select * from Users ";
	$sql .="where userName = '$userName'";

	$result = mysqli_query($con, $sql);
	$num = mysqli_num_rows($result);
	$row = mysqli_fetch_array($result);


	if($num!=0 && $passwordHash==$row["userPassword"])
		echo $row["userID"];
	else echo "invalid ";

	mysqli_free_result($result);
	mysqli_close($con);
?>