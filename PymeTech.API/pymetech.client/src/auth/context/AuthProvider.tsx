import { useState, type ReactNode } from "react";
import { AuthContext } from "./AuthContext";
import { authService } from "../services/authService";

import type {
    LoginRequest,
    LoginResponse,
    User,
} from "../types/authTypes";

interface AuthProviderProps {
    children: ReactNode;
}

export function AuthProvider({ children }: AuthProviderProps) {
    const [user, setUser] = useState<User | null>(authService.getCurrentUser());

    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(
        !!authService.getToken()
    );

    const login = async (credentials: LoginRequest): Promise<LoginResponse> => {
        const data = await authService.login(credentials);

        authService.saveSession(data);

        const currentUser = authService.getCurrentUser();

        setUser(currentUser);
        setIsAuthenticated(true);

        return data;
    };

    const logout = (): void => {
        authService.logout();

        setUser(null);
        setIsAuthenticated(false);
    };

    return (
        <AuthContext.Provider
            value={{
                user,
                isAuthenticated,
                login,
                logout,
            }}
        >
            {children}
        </AuthContext.Provider>
    );
}