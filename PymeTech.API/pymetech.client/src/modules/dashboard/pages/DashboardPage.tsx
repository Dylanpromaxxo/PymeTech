import { useNavigate } from "react-router-dom"; 
import { useAuth } from "../../../auth/hooks/useAuth";

function DashboardPage()
{
    const navigate = useNavigate();
    const { user, logout } = useAuth(); 

    const handleLogout = () : void =>
    {
        logout();
        navigate("/login")
    }



return (
    <div className="dashboard-page">
        <h1>Dashboard</h1>

        <p>Bienvenido a PymeTech.</p>

        {user && (
            <div className="user-card">
                <p>
                    <strong>Usuario:</strong> {user.nombre}
                </p>
                <p>
                    <strong>Email:</strong> {user.email}
                </p>
                <p>
                    <strong>Rol:</strong> {user.rol ?? "Sin rol"}
                </p>
            </div>
        )}

        <button onClick={handleLogout}>Cerrar sesion</button>
    </div>
);
};

export default DashboardPage;