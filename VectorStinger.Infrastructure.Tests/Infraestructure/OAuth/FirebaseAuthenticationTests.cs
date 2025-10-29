﻿using VectorStinger.Core.Domain.Infrastructure.Oauth;
using VectorStinger.Infrastructure.OAuth.Implement;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class FirebaseAuthenticationTests
{
    [Fact]
    public async Task AuthenticateAsync_ReturnsMappedUserFromProvider()
    {
        // Arrange
        var providerName = "google.com";
        var accessToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ijg3NzQ4NTAwMmYwNWJlMDI2N2VmNDU5ZjViNTEzNTMzYjVjNThjMTIiLCJ0eXAiOiJKV1QifQ.eyJuYW1lIjoiUlVCRU4gREFSSU8gQ0hBTENPIENBTVBPUyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS9BQ2c4b2NLOEZvbFg3SExUR1ZfMFdtOHJvUVFoTVFxQWdkbmtoOTJFLTd1VjB1Y0tWVTlXM1ZuWi13PXM5Ni1jIiwiaXNzIjoiaHR0cHM6Ly9zZWN1cmV0b2tlbi5nb29nbGUuY29tL2phdG8tYXBwLWIyYjNkIiwiYXVkIjoiamF0by1hcHAtYjJiM2QiLCJhdXRoX3RpbWUiOjE3NTE3NjUxODUsInVzZXJfaWQiOiIzazByR2w3SVB3VnN5Ym4yMVJZU1JXdkVLVUkyIiwic3ViIjoiM2swckdsN0lQd1ZzeWJuMjFSWVNSV3ZFS1VJMiIsImlhdCI6MTc1MTc2NTE4NSwiZXhwIjoxNzUxNzY4Nzg1LCJlbWFpbCI6Im5lYnVyLmRhcmlvQGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7Imdvb2dsZS5jb20iOlsiMTE4MTQ1NDAzNjA3NDg1MjU1MTIxIl0sImVtYWlsIjpbIm5lYnVyLmRhcmlvQGdtYWlsLmNvbSJdfSwic2lnbl9pbl9wcm92aWRlciI6Imdvb2dsZS5jb20ifX0.wK4Z6C-eJLn72Sn-rzjV-lYDoVLVAC_WKnlEviSyhQLJWturOhTfaVBjTd3Pqqyih8bo73cFqYrrxAt3Ch1_c_FKqvRvgKHK2z-QYqw78pr5YyufiuSGiMe4F4NVV9LqymJf9hx9VRZ7DUW8hnkgYmC-0mLVvXcnpqjK1c4k_Lce9d-_tgx3plCG6agaciBYAuKRzuNeyTVv5QueBWbzhPhSq6rj5DNPSJ2ivNhFMXQDk0jrqtjlu4lSYuNU_5U3d6i_uGTWcxI6OTMPUuKAlTpuqOjXUd2c781OlR8BIEqkZAghrgPU4xWIws0SxfYA5Ns_TwQKvwzKp5Xt7O0IUA";
        FirebaseAuthentication firebaseAuthentication = new FirebaseAuthentication();

        var result = await firebaseAuthentication.AuthenticateAsync(providerName, accessToken);

        // Assert
        Assert.NotEqual(null, result);
    }
}

