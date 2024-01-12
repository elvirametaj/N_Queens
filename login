
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Page</title>
    <style>
        body {
            margin:0;
            padding: 0;
            font-family: Arial, sans-serif;
            background-color: #192a56;
            display: flex;
            height: 100vh;
            align-items: center;
            justify-content: center;
        }

        .login-container {
            display: flex;
            background-color: #5497c4;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 800px;
            height: 700px;
        }

        .left-side {
            flex: 1;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #237ab4;
        }
        #username{
            border-radius: 18px;
            padding: 20px; 
            width: 200px;
            height: 15px;   
        }
        .left-side img {
            width: 100%;
            height: 100%;
            max-width: 400px;
        }

        .right-side {
            margin-top: 50px;
            flex: 1;
            padding: 20px;
        }

        .login-form {
            max-width: 400px;
            margin: 80px;
        }

        .login-form label {
            display: block;
            margin-bottom: 8px;
        }

        .login-form input {
            width: 100%;
            padding: 8px;
            margin-bottom: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        button {
            padding: 20px 40px;
            font-size: 20px;
            background-color: #3498db;
            color: white;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            margin-left: 100px;
            transition: background-color 0.3s ease;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <div class="left-side">
            <img src="C:\Users\Vjosa\Pictures\chessimg.png" alt="Chess Image">
        </div>
        <div class="right-side">
            <div class="login-form">
                <h2>Welcome to the game</h2>
                <form id="login-form" onsubmit="submitLogin(event)">
                    <input type="text" placeholder="Username" id="username" name="username" required>
                </form>
                </div>
                <div id="startbtn">
                    <button type="submit">Start</button>
                </div>
                
            </div>
        </div>
    </div>

    <script>
        function submitLogin(event) {
            event.preventDefault(); // Prevent form submission to a server for this example

            var username = document.getElementById('username').value;

            // For simplicity, let's assume the login is successful
            // You should perform proper validation and authentication here

            // Update the welcome message with the user's name
            alert("Welcome, " + username + "!"); // Replace this with your desired action
        }
    </script>
</body>
</html>
