/*
 * Ashton Lively
 * IObserver.cs
 * Assignment 3
 * Contains methods for observers.
 */

public interface IObserver
{
    void UpdateData(bool playerInShadow, bool sneaking, float playerSpeed);
}
