export interface LoginRequest {
    codigoEmpresa: string;
    email: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    idUsuario: number;
    nombre: string;
    email: string;
    nombreRol: string;
    idTenant: number;
}

export interface User {
    idUsuario: number;
    idTenant: number;
    nombre: string;
    email: string;
    rol: string;
}

export interface AuthContextType {
    user: User | null;
    isAuthenticated: boolean;
    login: (credentials: LoginRequest) => Promise<LoginResponse>;
    logout: () => void;
}