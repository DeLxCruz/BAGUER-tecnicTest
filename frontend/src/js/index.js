document
  .getElementById("loginForm")
  .addEventListener("submit", async (event) => {
    event.preventDefault();

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    try {
      const response = await login(username, password);
      handleLoginResponse(response);
    } catch (error) {
      console.error("Error:", error);
    }
  });

document.addEventListener("DOMContentLoaded", () => {
  const token = localStorage.getItem("token");

  if (!token) {
    window.location.href = "login.html";
  }
});

async function login(username, password) {
  const url = "http://localhost:5212/api/User/login";
  const body = JSON.stringify({ username, password });
  const headers = {
    "Content-Type": "application/json",
  };

  try {
    const response = await fetch(url, {
      method: "POST",
      headers,
      body,
    });
    if (!response.ok) {
      throw new Error("Failed to login");
    }
    return await response.json();
  } catch (error) {
    throw error;
  }
}

function handleLoginResponse(response) {
  const token = response.token;
  localStorage.setItem("token", token);
  window.location.href = "index.html";
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("registerForm").addEventListener("submit", async (event) => {
        event.preventDefault(); // Evitar que el formulario se envíe de forma predeterminada

        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;
        const name = document.getElementById("name").value;

        try {
            const response = await register(email, password, name);
            console.log("Registro exitoso:", response);
        } catch (error) {
            console.error("Error:", error);
        }
    });
});

async function register(email, password, name) {
    const url = "URL_DE_TU_ENDPOINT_DE_REGISTRO";
    const body = JSON.stringify({ username: email, password, name });
    const headers = {
        "Content-Type": "application/json"
    };

    try {
        const response = await fetch(url, {
            method: "POST",
            headers,
            body
        });
        if (!response.ok) {
            throw new Error("Error al registrar");
        }
        return await response.json();
    } catch (error) {
        throw error;
    }
}

