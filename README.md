# LSEG.LogMonitoringApp

# Log Monitoring Application

A modular WPF application for analyzing log files and displaying statistics about scheduled and background jobs.

## Overview

This project provides a simple UI for loading `.log` files, parsing entries that indicate job start and end times, and displaying useful information such as:

- Job ID (PID)
- Description
- Start and End time
- Duration
- Status based on duration (OK / Warning / Error)

## Features

- Modular architecture (manually implemented)
- MVVM pattern for separation of concerns
- Region-based view injection (custom RegionManager)
- Cross-module communication via a lightweight EventAggregator
- File selection using OpenFileDialog
- Real-time job statistics summary

## Architecture

The app is built using:

- MVVM – All views have view models with property binding and commands
- Custom RegionManager – For injecting views into named UI regions
- Custom EventAggregator – For sending messages (like job count) between modules
- Modules – Each feature (Log Analyzer, Statistics) is a separate module implementing `IModule`

## How it works

1. On startup, modules are manually registered and initialized by a `Bootstrapper`.
2. `LogAnalyzerModule` registers a main view that lets users load log files and see job details.
3. `LogStatsModule` injects a statistics view into a nested region within the analyzer view.
4. When logs are loaded, a `JobCountMessage` is published using the EventAggregator.
5. The statistics module listens for that message and updates the UI accordingly.

## Technologies

- WPF (.NET 8)
- C#
- MVVM (custom)
- No third-party frameworks

## Folder Structure (simplified)
