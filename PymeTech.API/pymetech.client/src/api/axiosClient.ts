import axios from "axios"; 


const axiosClient = axios.create({
    baseURL: "https://localhost:7177/api/v1",
    headers:
    {
        "Content-Type": "application/json",
    },

});

axiosClient.interceptors.request.use((config) => {
    const token = localStorage.getItem("access_token");

    if (token) {
        config.headers.Authorization = `Bearer ${token}`
    }
    return config; 

});

export default axiosClient; 