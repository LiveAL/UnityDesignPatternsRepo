/*
 * Ashton Lively
 * ISubject.cs
 * Assignment 3
 * Contains methods for subjects.
 */

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
