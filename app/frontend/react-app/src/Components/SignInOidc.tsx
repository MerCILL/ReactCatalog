import { useAuth } from "oidc-react";
import { useEffect } from "react";

export default function SignInOidc() {
    const { userData, isLoading } = useAuth();
  
    useEffect(() => {
      if (!isLoading && userData) {
        window.location.href = '/home';
      }
    }, [isLoading, userData]);
  
    return null;
  }
  