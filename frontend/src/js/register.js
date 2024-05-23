document.addEventListener("DOMContentLoaded", () => {
    const registerForm = document.getElementById("registerForm");
    if (registerForm) {
      registerForm.addEventListener("submit", async (event) => {
        event.preventDefault();
        const username = document.getElementById("user").value;
        const password = document.getElementById("password").value;
        const name = document.getElementById("name").value;
        try {
          const response = await register(username, password, name);
          if (typeof response === "string") {
            showSuccessToast(response);
          } else {
            showSuccessToast("Registro exitoso");
          }
        } catch (error) {
          showErrorToast("Error al registrar");
          console.error(error);
        }
      });
    }
  });
  
  async function register(username, password, name) {
    const url = "http://localhost:5212/api/User/register";
    const body = JSON.stringify({ username, password, name });
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
        throw new Error("Error al registrar");
      }
      if (response.headers.get("content-type").startsWith("text/plain")) {
        return response.text(); // Devolver texto plano
      } else {
        const responseData = await response.json();
        return responseData;
      }
    } catch (error) {
      throw error;
    }
  }
  
  function showSuccessToast(message) {
    const toastDiv = document.querySelector(".toast");
    const alertDiv = document.createElement("div");
    alertDiv.classList.add("alert", "alert-success");
    alertDiv.innerHTML = `<span>${message}</span>`;
    toastDiv.innerHTML = "";
    toastDiv.appendChild(alertDiv);
    setTimeout(() => {
      toastDiv.innerHTML = "";
    }, 3000);
  }
  
  function showErrorToast(message) {
    const toastDiv = document.querySelector(".toast");
    const alertDiv = document.createElement("div");
    alertDiv.classList.add("alert", "alert-error");
    alertDiv.innerHTML = `<span>${message}</span>`;
    toastDiv.innerHTML = "";
    toastDiv.appendChild(alertDiv);
    setTimeout(() => {
      toastDiv.innerHTML = "";
    }, 3000);
  }
  