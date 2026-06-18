import axiosClient from "../../api/axiosClient";
import type { LoginRequest, LoginResponse, User } from "../types/authTypes";

const TOKEN_KEY = "access_token";
const USER_KEY = "user";

export const authService = {
    login: async (credentials: LoginRequest): Promise<LoginResponse> => {
        const response = await axiosClient.post<LoginResponse>(
            "/Auth/login",
            credentials
        );

        return response.data;
    },

    saveSession: (data: LoginResponse): void => {
        localStorage.setItem(TOKEN_KEY, data.token);

        const user: User = {
            idUsuario: data.idUsuario,
            idTenant: data.idTenant,
            nombre: data.nombre,
            email: data.email,
            rol: data.nombreRol,
        };

        localStorage.setItem(USER_KEY, JSON.stringify(user));
    },

    logout: (): void => {
        localStorage.removeItem(TOKEN_KEY);
        localStorage.removeItem(USER_KEY);
    },

    getToken: (): string | null => {
        return localStorage.getItem(TOKEN_KEY);
    },

    getCurrentUser: (): User | null => {
        const user = localStorage.getItem(USER_KEY);

        if (!user) return null;

        return JSON.parse(user) as User;
    },
};