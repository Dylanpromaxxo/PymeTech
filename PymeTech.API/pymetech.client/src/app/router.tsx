import { createBrowserRouter, Navigate } from "react-router-dom";
import LoginPage from "../auth/pages/LoginPage";
import ProtectedRoute from "../auth/components/ProtectedRoute";
import DashboardPage from "../modules/dashboard/pages/DashboardPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Navigate to="/login" replace />,
    },
    {
        path: "/login",
        element: <LoginPage />,
    },
    {
        path: "/dashboard",
        element: (
            <ProtectedRoute>
                <DashboardPage />
            </ProtectedRoute>
        ),
    },
]);