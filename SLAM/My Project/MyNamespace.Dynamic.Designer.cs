using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SLAM.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Form1 m_Form1;

            public Form1 Form1
            {
                [DebuggerHidden]
                get
                {
                    m_Form1 = Create__Instance__(m_Form1);
                    return m_Form1;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Form1))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Form1);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public RenameForm m_RenameForm;

            public RenameForm RenameForm
            {
                [DebuggerHidden]
                get
                {
                    m_RenameForm = Create__Instance__(m_RenameForm);
                    return m_RenameForm;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_RenameForm))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_RenameForm);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public SelectKey m_SelectKey;

            public SelectKey SelectKey
            {
                [DebuggerHidden]
                get
                {
                    m_SelectKey = Create__Instance__(m_SelectKey);
                    return m_SelectKey;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_SelectKey))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_SelectKey);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public SettingsForm m_SettingsForm;

            public SettingsForm SettingsForm
            {
                [DebuggerHidden]
                get
                {
                    m_SettingsForm = Create__Instance__(m_SettingsForm);
                    return m_SettingsForm;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_SettingsForm))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_SettingsForm);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public SetVolume m_SetVolume;

            public SetVolume SetVolume
            {
                [DebuggerHidden]
                get
                {
                    m_SetVolume = Create__Instance__(m_SetVolume);
                    return m_SetVolume;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_SetVolume))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_SetVolume);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public TrimForm m_TrimForm;

            public TrimForm TrimForm
            {
                [DebuggerHidden]
                get
                {
                    m_TrimForm = Create__Instance__(m_TrimForm);
                    return m_TrimForm;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_TrimForm))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_TrimForm);
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            public YTImport m_YTImport;

            public YTImport YTImport
            {
                [DebuggerHidden]
                get
                {
                    m_YTImport = Create__Instance__(m_YTImport);
                    return m_YTImport;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_YTImport))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_YTImport);
                }
            }
        }
    }
}