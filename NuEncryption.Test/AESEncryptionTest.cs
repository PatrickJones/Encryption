using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NuEncryption.Test
{
    [TestClass]
    public class AESEncryptionTest
    {
        private readonly string encryptString = "M#P@ssw0rd123";

        /// <summary>
        /// Returns encrypted string from a text
        /// </summary>
        [TestMethod]
        public void Encrypt_ShouldReturnStringEncrypted()
        {
            //Arrange
            //Act
            var encrypted = AESEncryption.Encrypt(encryptString);
            //Assert
            Assert.AreEqual(64, encrypted.Length);
            Assert.AreNotEqual(encryptString, encrypted);
        }

        /// <summary>
        /// Returns encrypted string from a text
        /// </summary>
        [TestMethod]
        public void Encrypt_EncryptedStringLengthBase64()
        {
            //Arrange
            //Act
            var encrypted = AESEncryption.Encrypt(encryptString);
            //Assert
            Assert.AreEqual(64, encrypted.Length);
        }

        /// <summary>
        /// Returns decrypted string
        /// </summary>
        [TestMethod]
        public void Decrypt_ShouldReturnStringDecrypted()
        {
            //Arrange
            const string decryptString = "7Ph4a7D5vLSJccbHGxojCByaXvBFn6kwW4UZAx10EkQVynabuGmC4QjPzaBmsoZS";

            //Act
            var decrypted = AESEncryption.Decrypt(decryptString);

            //Assert
            Assert.AreEqual(encryptString, decrypted);
        }

        /// <summary>
        /// Returns decrypted string
        /// </summary>
        [TestMethod]
        public void Decrypt_ShouldNotDecryptCorrectly()
        {
            //Arrange
            const string decryptHackString = "lPh4a7D5vLopccbHGxojCByaXvBFn6kwW4UZAx10EkQVynabuGmC4QjPzaBmsoZS";

            //Act
            var decrypted = AESEncryption.Decrypt(decryptHackString);

            //Assert
            Assert.AreNotEqual(encryptString, decrypted);
        }

    }
}
