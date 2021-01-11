function validation() {
    var firstname = document.getElementById('fname').value;
    var lastname = document.getElementById('lname').value;
    var City = document.getElementById('citys').value;
    var State = document.getElementById('states').value;
    var Zip = document.getElementById('pin').value;
    var emailId = document.getElementById('emails').value;
    var mobile = document.getElementById('mobile').value;
    var password = document.getElementById('passwords').value;
    var confirmpasword = document.getElementById('password1').value;

    var name = /[a-z]/;
    var city = /[a-z]/;
    var state = /[a-z]/;
    var pass = /^(?=.*[A-Z])[a-zA-Z]{1,6}[!@#$%^&*][0-9]{1,3}$/;
    var email = /^[a-zA-Z0-9.]{1,}@[a-z]{1,5}[.a-z]{1,5}[.]{1}[a-z]{1,4}$/;
    var mobileno = /^[6789]{1}[0-9]{9}$/;
    var zipcode = /^[0-9]{6}$/;

    if (zipcode.test(Zip)) {
        document.getElementById('pinError').innerHTML = ""
    }
    else {
        document.getElementById('pinError').innerHTML = "Enter 6 Digit";
        return false;
    }

    if (city.test(City))
    {
        document.getElementById('cityError').innerHTML = " "
    }
    else {
        document.getElementById('cityError').innerHTML = " Enter valid City.";
        return false;
    }

    if (state.test(State)) {
        document.getElementById('stateError').innerHTML = " "
    }
    else {
        document.getElementById('stateError').innerHTML = " Enter valid State.";
        return false;
    }


    if (name.test(firstname)) {
        document.getElementById('nameError').innerHTML = " ";

    } else {
        document.getElementById('nameError').innerHTML = "Invalid Username.";
        return false;
    }

    if (name.test(lastname)) {
        document.getElementById('namesError').innerHTML = " ";

    } else {
        document.getElementById('namesError').innerHTML = "*****Invalid Username.";
        return false;
    }

    if (pass.test(password)) {
        document.getElementById('passError').innerHTML = " ";

    } else {
        document.getElementById('passError').innerHTML = "*****Invalid Password.";
        return false;
    }

    if (pass.match(confirmpasword)) {
        document.getElementById('checkpassError').innerHTML = " ";

    } else {
        document.getElementById('checkpassError').innerHTML = "*****Password not match.";
        return false;
    }

    if (emailId.test(email)) {
        document.getElementById('emailError').innerHTML = " ";

    } else {
        document.getElementById('emailError').innerHTML = "*****Invalid Email.";
        return false;
    }

    if (mobileno.test(mobile)) {
        document.getElementById('mobileError').innerHTML = " ";

    } else {
        document.getElementById('mobileError').innerHTML = "*****Invalid Mobile Number.";
        return false;
    }
} 