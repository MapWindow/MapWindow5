<?php
// define variables and set to empty values
$name = $email = $emailErr = $nameErr = "";
$foundError = false;
$reg_date = date("m/d/Y");

function test_input($data) {
  $data = trim($data);
  $data = stripslashes($data);
  $data = htmlspecialchars($data);
  return $data;
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="MapWindow is an Open Source GIS desktop application. Subscribe at this page to the newsletter">
    <meta name="keywords" content="mapwindow, mapwindows, mapwingis, open, source, open source, open-source, gis, desktop, application, subscribe, newletter">
    <meta name="author" content="Paul Meems">
    <link rel="icon" href="../../favicon.ico">

    <title>Subscribe to the MapWindow 5 newsletter</title>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/mw5.css">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body>

    <!-- Main jumbotron for a primary marketing message or call to action -->
    <section class="jumbotron">
        <div class="container">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 pull-right ">
                <img class="img-responsive" src="img/LogoMapWindow_5.jpg" width="812" height="143" alt="MapWindow 5 - open source GIS Desktop Application" />
            </div>
        </div>
    </section>
<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $name = test_input($_POST["name"]);
    // check if name only contains letters and whitespace
    if (!preg_match("/^[a-zA-Z ]*$/",$name)) {
      $nameErr = "Only letters and white space allowed"; 
        $foundError = true;
    }

  if (empty($_POST["email"])) {
      $emailErr = "Email is required";
      $foundError = true;
  } else {
    $email = test_input($_POST["email"]);
    // check if e-mail address is well-formed
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $emailErr = "Invalid email format"; 
        $foundError = true;
    }
  }

    if (!$foundError){
        // Write e-mail to file:
        $myFile = "newEmails.csv";
        $fhCorrect = fopen($myFile, 'a') or die("Can't open file: " + $myFile);
        fwrite($fhCorrect, $email . "," . $reg_date . "\n");
        fclose($fhCorrect);
        
        // Show user:
        echo "<section class=\"container\">";
        echo "<div class=\"row\">";
        echo "<article class=\"col-md-12 col-xs-12\">";
        echo "<h1>Subscription was successful!</h1>";
        echo "<p>Thank you $name. You subscribed successful to our newsletter using $email</p>";
        echo "</article>";
        echo "</div>";
        echo "</section>";
    } else {
        if ($nameErr != "") {
            $nameErr = "<span class=\"alert alert-danger\" role=\"alert\">$nameErr</span>";
        }
        if ($emailErr != "") {
            $emailErr = "<span class=\"alert alert-danger\" role=\"alert\">$emailErr</span>";
        }
    }
}
?>    
    <section class="container">
        <div class="row">
            <article class="col-md-12 col-xs-12">
                <h1>Subscribe to our newsletter</h1>
                <p>If you want to keep informed about the progress the MapWindow project you should subscribe to our newsletter.<br />
                We send them irregurarly, mostly when we have published a new release for MapWindow5 or MapWinGIS.</p>
                <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">
                    Name: <input type="text" name="name" size="30" placeholder="Enter your name"> <?php echo $nameErr;?><br><br>
                    E-mail: <input type="email" name="email" size="30" required placeholder="Enter a valid email address"> * <?php echo $emailErr;?><br><br>
                    <input type="submit">
                </form>
                <br>
                We will not sell or show your e-mail address to any third-party. We use SendGrid to send the newsletters. In every newsletter is an unsubscribe link.
                <br><br>
            </article>
        </div>
    </section>

    <section class="container">
        <div class="row" style="background-color: white">
            <article class="col-md-4 col-xs-12">
                <!-- 300x250 ad tag -->
                <div data-type="ad" data-publisher="mapwindow.org" data-zone="ron" data-format="300x250" data-tags="GIS%2cMapping%2cMap%2cC%23%2cMaps%2cWMS%2cgeospatial"></div>
            </article>
            <article class="col-md-4 hidden-xs">
                <div data-type="ad" data-publisher="mapwindow.org" data-zone="ron" data-format="300x250" data-tags="open%2csource%2cdesktop%2cNET2cmicrosoft"></div>
            </article>
            <article class="col-md-4 hidden-xs">
                <div data-type="ad" data-publisher="mapwindow.org" data-zone="ron" data-format="300x250" data-tags="GIS%2csyncfusion%2cfree"></div>
            </article>
        </div>

        <hr>

        <footer class="hidden-xs">
            <div class="footer-ad" data-type="ad" data-publisher="mapwindow.org" data-zone="ron"
                 data-format="728x90" data-tags="GIS%2cMapping%2cMap%2cC%23%2cMaps%2cWMS%2cgeospatial">&nbsp;</div>
            <p>&copy; MapWindow Developers Team 2015</p>
        </footer>
    </section> <!-- /container -->
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="http://getbootstrap.com/assets/js/ie10-viewport-bug-workaround.js"></script>

    <script type="text/javascript">
        function _dmBootstrap(file) {
            var _dma =
                document.createElement('script'); _dma.type = 'text/javascript'; _dma.async = true;
            _dma.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + file;
            (document.getElementsByTagName('head')[0] ||
            document.getElementsByTagName('body')[0]).appendChild(_dma);
        } function _dmFollowup(file)
        { if (typeof DMAds === 'undefined') _dmBootstrap('cdn2.DeveloperMedia.com/a.min.js'); }
        (function () {
            _dmBootstrap('cdn1.DeveloperMedia.com/a.min.js'); setTimeout(_dmFollowup,
            2000);
        })();</script>

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] ||
                function () { (i[r].q = i[r].q || []).push(arguments) }, i[r].l = 1 * new Date(); a =
                s.createElement(o), m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g;
            m.parentNode.insertBefore(a, m)
        })(window, document, 'script',
            '//www.google-analytics.com/analytics.js', 'ga'); ga('create', 'UA-5161528-17', 'auto');
        ga('require', 'displayfeatures'); ga('send', 'pageview');</script>
</body>
</html>
