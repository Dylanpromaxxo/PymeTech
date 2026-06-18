import { useState, type ChangeEvent, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";
import type { LoginRequest } from "../types/authTypes";

function LoginPage() {
    const navigate = useNavigate();
    const { login } = useAuth();

    const [form, setForm] = useState<LoginRequest>({
        codigoEmpresa: "",
        email: "",
        password: "",
    });

    const [error, setError] = useState<string>("");
    const [loading, setLoading] = useState<boolean>(false);

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;

        setForm({
            ...form,
            [name]: value,
        });
    };

    const handleSubmit = async (
        e: FormEvent<HTMLFormElement>
    ): Promise<void> => {
        e.preventDefault();

        if (!form.codigoEmpresa.trim()) {
            setError("Ingresa el codigo de empresa");
            return;
        }

        if (!form.email.trim()) {
            setError("Ingresa tu correo");
            return;
        }

        if (!form.password.trim()) {
            setError("Ingresa tu contrasena");
            return;
        }

        try {
            setError("");
            setLoading(true);

            await login({
                codigoEmpresa: form.codigoEmpresa.trim(),
                email: form.email.trim(),
                password: form.password,
            });

            navigate("/dashboard");
        } catch (error) {
            console.error(error);
            setError("Codigo de empresa, correo o contrasena incorrectos");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-page">
            <form className="login-form" onSubmit={handleSubmit}>
                <h1>PymeTech</h1>
                <p>Inicia sesion para continuar</p>

                <div className="form-group">
                    <label htmlFor="codigoEmpresa">Codigo de empresa</label>
                    <input
                        id="codigoEmpresa"
                        type="text"
                        name="codigoEmpresa"
                        value={form.codigoEmpresa}
                        onChange={handleChange}
                        placeholder="Ej: PYME001"
                        autoComplete="organization"
                        required
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="email">Correo</label>
                    <input
                        id="email"
                        type="email"
                        name="email"
                        value={form.email}
                        onChange={handleChange}
                        placeholder="some@gmail.com"
                        autoComplete="email"
                        required
                    />
                </div>

                <div className="form-group">
                    <label htmlFor="password">Contrasena</label>
                    <input
                        id="password"
                        type="password"
                        name="password"
                        value={form.password}
                        onChange={handleChange}
                        placeholder="********"
                        autoComplete="current-password"
                        required
                    />
                </div>

                {error && <span className="error">{error}</span>}

                <button type="submit" disabled={loading}>
                    {loading ? "Ingresando..." : "Ingresar"}
                </button>
            </form>
        </div>
    );
}

export default LoginPage;   